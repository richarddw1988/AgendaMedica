import { PessoaModel } from './pessoa-model';

describe('PessoaModel:', () => {
  it('deve ser criado uma instancia', () => {
    expect(new PessoaModel()).toBeTruthy();
  });
});
